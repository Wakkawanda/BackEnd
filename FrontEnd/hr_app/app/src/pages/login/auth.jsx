import React, { useState } from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap';
import axios from 'axios';
import { Navigate } from 'react-router-dom';

function Login() {
  const [username, setUsername] = useState('');
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
  // const handleSubmit = (event) => {
  //   event.preventDefault();
  //   console.log('Login attempted with:', { email, password });
    // Here you would typically send a request to your server
  

  return (
    <Container>
      <Row className="justify-content-md-center mt-5">
        <Col xs={12} md={6}>
          <h2 className="text-center mb-4">Login</h2>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Корпоративынй логин</Form.Label>
              <Form.Control
                id="login"
                type="text"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Пароль</Form.Label>
              <Form.Control
                id="password"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </Form.Group>

            <Button variant="primary" type="submit" className="w-100">
              Login
            </Button>
          </Form>
          {message && <p>{message}</p>}
        </Col>
      </Row>
    </Container>
  );
}

export default Login;