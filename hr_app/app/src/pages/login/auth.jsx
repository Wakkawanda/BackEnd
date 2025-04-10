import React, { useState } from 'react';
import axios from 'axios';

const Login = () => {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7100/api/auth/login', { // Замените URL на ваш API endpoint
        login,
        password
      });

      if (response.status === 200) { // Проверяем HTTP статус 200 OK
        // Предполагаем, что API возвращает { success: true/false, message: "...", token: "..." }
        if (response.data.success) {
          setMessage(response.data.message || 'Успешный вход');
          // Сохраняем токен (если он есть)
          localStorage.setItem('token', response.data.token); // Или в cookie, sessionStorage, etc.
        } else {
          setMessage(response.data.message || 'Ошибка входа: неверные учетные данные');
        }
      } else {
        setMessage(`Ошибка: HTTP ${response.status}`); // Отображаем HTTP статус ошибки
      }

    } catch (error) {
      console.error('Ошибка при аутентификации:', error);

      if (error.response) {
        // Сервер вернул код ошибки, отличный от 2xx
        setMessage(`Ошибка: ${error.response.status} ${error.response.statusText}`); // Отображаем статус ошибки и текст ошибки
        console.log('Response data:', error.response.data);  //Вывод данных ответа
        console.log('Response headers:', error.response.headers); //Вывод заголовков ответа

      } else if (error.request) {
        // Запрос был сделан, но ответ не был получен
        setMessage('Ошибка: Нет ответа от сервера');
      } else {
        // Произошла ошибка при настройке запроса
        setMessage('Ошибка: Не удалось выполнить запрос');
      }
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
              value={login}
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