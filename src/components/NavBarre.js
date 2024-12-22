import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './css/NavBar.css'
const NavBar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginLogout = () => {
    setIsLoggedIn(!isLoggedIn);
  };

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <div className="navbar-brand">
          <Link to="/">Gestion Ressources</Link>
        </div>
        <div className="navbar-links">
          <Link to="/" onClick={handleLoginLogout}>
            {isLoggedIn ? 'Connexion' : 'Déconnexion'}
          </Link>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
