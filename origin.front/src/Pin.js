import React, { useState } from 'react';
import { useParams, useNavigate } from "react-router-dom";
import Axios from "axios";
import Swal from 'sweetalert2'

const Pin = (props) => {
  const [pin, setPin] = useState("");
  const [attempt, setAttempt] = useState(1);
  
  const { id } = useParams();
  const navigate = useNavigate();

  const verificatePin = async () => {
    const res = await Axios.post(`https://localhost:7208/api/card/verify/pin`, { id: id, pin: pin });
    return await res;
  }

  const lockPin = async () => {
    const res = await Axios.put(`https://localhost:7208/api/card/lock`, { id: id });
    return await res;
  }

  const onClick = () => {
    const regNumber = /^[0-9]*$/;
    if (!regNumber.test(pin)) {
      Swal.fire({
        icon: 'error',
        title: 'Pin Obligatorio',
        text: 'Solo digitos.'
      });
      return;
    }
    if (pin.length !== 4) {
      Swal.fire({
        icon: 'error',
        title: 'Pin Obligatorio',
        text: 'Consta de 4 digitos numericos.'
      });
      return;
    }
    verificatePin()
      .then(response => {
        navigate(`/operations/${id}`);
      })
      .catch(error => {
        Swal.fire({
          icon: 'error',
          title: `${error.response.data.msj}`,
          text: `Cantidad de intentos: ${attempt}`
        });
        setAttempt(attempt + 1)
      });

    if (attempt === 4) {
      lockPin()
        .then(response => {
          Swal.fire({
            icon: 'error',
            title: `Pin Bloqueado.`,
            text: `Contactarse con la sucursal mas cercana.`
          });
          navigate(`/`);
        })
        .catch(error => {
          console.log(error);
        })
    }
  }

  const OnChange = (event) => {
    setPin(event.target.value);
  }

  const resetPin = () => {
    setPin("");
  }

  const logOut = () => {
    navigate("/");
  }

  return (
    <div className='container d-flex justify-content-center align-items-center' style={{ width: "100vw", height: "100vh" }}>
      <div>
        <label htmlFor="pin" className="form-label">Pin</label>
        <input type='text' maxLength={4} className="form-control" id="pin" placeholder="1234" onChange={OnChange} value={pin} />
        <div className='mt-2'>
          <button type="button" className="btn btn-primary" style={{ marginRight: "15px" }} onClick={onClick}>Aceptar</button>
          <button type="button" className="btn btn-secondary" style={{ marginRight: "15px" }} onClick={resetPin}>Limpiar</button>
          <button type="button" className="btn btn-danger" onClick={logOut}>Salir</button>
        </div>
      </div>
    </div>
  )
}

export default Pin;