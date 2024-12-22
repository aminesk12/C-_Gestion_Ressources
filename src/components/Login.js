import React, { useState } from 'react';
import { Link } from "react-router-dom";
import './css/style.css'
function LoginForm() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [msg, setMsg] = useState('');
    const [user, setUser] = useState(null);

    const handleSubmit = (event) => {
        event.preventDefault();
       
        console.log('Submitted:', { login, password });
        testLogin(login, password);
    };

    const testLogin = (login, password) => {
        fetch('https://localhost:7251/api/LoginApi')
            .then(response => response.json())
            .then(data => {
                let foundUser = null;
                for (let i = 0; i < data.length; i++) {
                    const user = data[i];
                    if (user.login === login && user.password === password) {
                        foundUser = user;
                        break;
                    }
                }
    
                if (foundUser) {
                    setUser(foundUser); // Store the user data in the state
                    setMsg('Login successful');
                    
                    // Log the user data
                    console.log('User data:', foundUser);
                    
                    // Redirect based on role after a short delay to ensure state update
                    setTimeout(() => {
                        switch (foundUser.role) {
                            case 0: // Fournisseur
                                window.location.href = "/liste-appel-offers";
                                break;
                            case 1: // Responsable
                                window.location.href = "/liste-Besoins";
                                break;
                            case 2: // Chef Departement
                                window.location.href = "/Responsable/liste-appel-offers";
                                break;
                            case 3: // Enseignant/PersonDepartement
                                window.location.href = "/ajouter-besoin";
                                break;
                            default:
                                setMsg('Unknown role');
                        }
                    }, 500);
                } else {
                    setMsg('Invalid login or password');
                }
            })
            .catch(error => {
                console.error('Error fetching data:', error);
                setMsg('Error fetching data from the API');
            });
    };

    return (
        <section className="main">
            <div className="layer">
                <div className="bottom-grid"></div>
                <br />
                <br />
                <br />
                <br />
                <div className="content-w3ls">
                    <div className="text-center" style={{ color: 'white', fontSize: '20px', fontFamily: 'Arial' }}>
                        Connectez-vous
                    </div>
                    <br />
                    <br />
                    <div className="content-bottom">
                        <form onSubmit={handleSubmit}>
                            <div className="field-group">
                                <span className="fa fa-user" aria-hidden="true"></span>
                                <div className="wthree-field">
                                    <input
                                        type="text"
                                        placeholder="Nom d'utilisateur"
                                        value={login}
                                        onChange={(e) => setLogin(e.target.value)}
                                    />
                                </div>
                            </div>
                            <div className="field-group">
                                <span className="fa fa-lock" aria-hidden="true"></span>
                                <div className="wthree-field">
                                    <input
                                        type="password"
                                        placeholder="Password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                    />
                                </div>
                            </div>
                            <div className="wthree-field">
                                <button type="submit" className="btn">Connexion</button>
                            </div>
                            <ul className="list-login">
                                <li className="clearfix"></li>
                            </ul>
                            <div style={{ color: 'white', fontSize: '20px' }}>
                                {msg}
                            </div>
                        </form>
                    </div>
                </div>
                <div className="bottom-grid1">
                    <div className="links">
                        <ul className="links-unordered-list">
                            <li className="">
                                <a href="#" className="">À propos de nous</a>
                            </li>
                            <li className="">
                                <a href="#" className="">Politique de confidentialité</a>
                            </li>
                            <li className="">
                                <a href="#" className="">Conditions d'utilisation</a>
                            </li>
                        </ul>
                    </div>
                    <div className="copyright">
                        <p>
                            © 2023 Clé. Tous les droits sont réservés |
                            <a href="#">App</a>
                        </p>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default LoginForm;
