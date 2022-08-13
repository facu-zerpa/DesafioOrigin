import React from 'react';

const Balance = (props) => {
  const { number, dueDate, balance } = props.data;

  const formatNumber = (number) => {
    return `${number.slice(0, 4)}-${number.slice(4, 8)}-${number.slice(8, 12)}-${number.slice(12, 16)}`
  }

  const formatDate = (date) => {
    return `${date.split(' ')[0]}`
  }

  return (
    <div className='mt-4'>
      <h1>Tarjeta: {formatNumber(number)}</h1>
      <h3>Fecha Vencimiento: {formatDate(dueDate)}</h3>
      <h2>Balance: ${balance}</h2>
    </div>
  );
}

export default Balance;