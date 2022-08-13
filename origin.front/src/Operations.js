import React, { useState } from 'react';
import { useParams, useNavigate } from "react-router-dom";
import Axios from "axios";
import Balance from './Balance';
import Withdraw from './Withdraw';

const Operations = () => {
  const [viewBalance, setViewBalance] = useState(false);
  const [viewWithdraw, setViewWithdraw] = useState(false);
  const [data, setData] = useState({});

  const { id } = useParams();
  const navigate = useNavigate();

  const balance = async () => {
    const res = await Axios.post(`https://localhost:7208/api/operation/balance`, { id: id });
    return await res;
  }

  const onClickBalance = () => {
    balance()
      .then(result => {
        setData(result.data);
        setViewWithdraw(false);
        setViewBalance(true);
      })
      .catch(error => {
        console.log(error);
      })
  }

  const onClickWithdraw = () => {
    setViewWithdraw(true);
    setViewBalance(false);
  }

  const logout = () => {
    navigate(`/`);
  }

  return (
    <div className='container text-center mt-3' style={{ width: "100vw", height: "100vh" }}>
      <button type="button" className="btn btn-primary" style={{ marginRight: "15px" }} onClick={onClickBalance}>Balance</button>
      <button type="button" className="btn btn-secondary" style={{ marginRight: "15px" }} onClick={onClickWithdraw}>Retirar</button>
      <button type="button" className="btn btn-danger" onClick={logout}>Salir</button>
      {viewBalance && <Balance data={data} />}
      {viewWithdraw && <Withdraw />}
    </div>
  )
}

export default Operations;