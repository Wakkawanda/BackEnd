import React, { useState } from 'react';
import axios from 'axios';
import { Navigate } from 'react-router-dom';

const Login = () => {
  const [username, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:44330/api/auth/login', {
        username,
        password
      });

      if (response.data.success) {
        setMessage('Вошёл');
        Navigate('/home');
      } else {
        setMessage('Не вошёл');
      }
    } catch (error) {
      console.error('Ошибка при аутентификации:', error);
      setMessage('Ошибка соединения');
    }
  };

  return (
    <div>
      <h2>Аутентификация</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="login">Логин:</label>
          <input
            id="login"
            type="text"
            value={username}
            onChange={(e) => setLogin(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="password">Пароль:</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit">Войти</button>
      </form>
      {message && <p>{message}</p>}
    </div>
  );
};

export default Login;