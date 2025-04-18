import React from "react";
import{BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Login from './pages/login/auth.jsx';
import Home from './pages/home/home.jsx';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/home" element={<Home />} />
      </Routes>
    </Router>
  );
}

export default App;
