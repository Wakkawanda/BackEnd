import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Home = () => {
  const [data, setData] = useState([]);  
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {

    axios
      .get('http://10.3.24.110:5288/api/auth/login')
      .then((response) => {
        console.log('Полученные данные:', response.data);
        setData(response.data.memberOf);
        setLoading(false);
      })
      .catch((err) => {
        console.error('Ошибка получения данных:', err);
        setError('Ошибка получения данных');
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Загрузка данных...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div style={{ margin: '20px', padding: '20px' }}>
      <h1>Главная страница</h1>
      {data.length > 0 ? (
        <ul>
          {data.map((item, index) => (
            <li key={item.id || index}>{JSON.stringify(item)}</li>
          ))}
        </ul>
      ) : (
        <p>Нет данных для отображения</p>
      )}
    </div>
  );
};

export default Home;