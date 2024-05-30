import React from 'react';

const Button = ({ onClick, children, type = 'button', disabled = false}) => {
    return (
      <button className='bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded'
        type={type}
        onClick={onClick}
        disabled={disabled}
      >
        {children}
      </button>
    );
  };

  export default Button;