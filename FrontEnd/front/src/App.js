// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './Login';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Login />} />
                {/* Add other routes for protected pages here */}
            </Routes>
        </Router>
    );
};

export default App;