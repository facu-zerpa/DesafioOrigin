import React, { useState } from 'react';
import { useParams } from "react-router-dom";
import Axios from "axios";
import DetailWithdraw from "./DetailWithdraw";
import Swal from 'sweetalert2'

const Withdraw = () => {
  const [ammount, setAmmount] = useState(0.00);
  const [operation, setOperation] = useState({});
  const [viewDetail, setViewDetail] = useState(false);

  const { id } = useParams();

  const withDraw = async () => {
    const res = await Axios.post(`https://localhost:7208/api/operation/withdraw`, { id: id, ammount: ammount });
    return await res;
  }

  const onClick = () => {
    if (ammount <= 0) {
      Swal.fire({
        icon: 'error',
        title: 'Monto incorrecto',
        text: 'Ingrese un valor distinto a 0'
      });
      return;
    }
    withDraw()
      .then(result => {
        setOperation(result.data)
        setViewDetail(true);
      })
      .catch(error => {
        Swal.fire({
          icon: 'error',
          title: `Saldo Insuficiente.`,
          text: `${error.response.data.msj}.`
        });
      })
  }

  const onChange = (event) => {
    setAmmount(parseFloat(event.target.value))
  }

  const limpiar = () => {
    setViewDetail(false);
    setOperation({});
    setAmmount(0.00);
  }

  return (
    <div className='container mt-4'>
      <div className='row d-flex justify-content-center'>
        <div className='col-3'>
          <label htmlFor="ammount" className="form-label">Monto</label>
          <input type='number' min={0.00} step="0.01" className="form-control" id="ammount" onChange={onChange} value={ammount} />
          <div className='d-flex justify-content-end'>
            <button type="button" className="btn btn-primary mt-2" onClick={onClick}>Aceptar</button>
            <button type="button" className="btn btn-secondary mt-2 mx-1" onClick={limpiar}>Limpiar</button>
          </div>
        </div>
        {viewDetail && <DetailWithdraw data={operation} />}
      </div>
    </div>
  )
}

export default Withdraw;