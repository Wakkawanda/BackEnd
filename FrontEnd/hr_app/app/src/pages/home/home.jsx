import React from 'react';
import { useLocation } from 'react-router-dom';

const Home = () => {
  const location = useLocation();
  const data = location.state?.data || {};

  return (
    <div style={{ margin: '20px', padding: '20px' }}>
      <h1>Главная страница</h1>
      <pre>{JSON.stringify(data, null, 2)}</pre>
    </div>
  );
};

export default Home;