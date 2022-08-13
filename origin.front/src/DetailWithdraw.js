import React from 'react';

const DetailWithdraw = (props) => {

  const { number, dateOperation, amount, balance } = props.data;

  // formato tarjeta 1111-1111-1111-1111
  const formatNumber = (number) => {
    return `${number.slice(0, 4)}-${number.slice(4, 8)}-${number.slice(8, 12)}-${number.slice(12, 16)}`
  }

  // formato dd/MM/yyyy hh:mm:ss
  const formatDate = (dateString) => {
    const dateOperation = new Date(dateString);
    const date = `${dateOperation.getDate()}/${dateOperation.getMonth() + 1}/${dateOperation.getFullYear()}`
    const hour = `${dateOperation.getHours()}:${dateOperation.getMinutes()}:${dateOperation.getSeconds()}`
    return `${date} ${hour}`
  }

  return (
    <div className='mt-4'>
      <h1>Tarjeta: {formatNumber(number)}</h1>
      <h2>Fecha Operacion: {formatDate(dateOperation)}</h2>
      <h2>Monto: ${amount}</h2>
      <h2>Balance: ${balance}</h2>
    </div>
  )
}

export default DetailWithdraw;