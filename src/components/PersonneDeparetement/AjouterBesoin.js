import React from 'react';
import { Link } from 'react-router-dom';

function AddNeed() {
    return (
        <div className="container">
            <div className="row justify-content-center align-items-center" style={{ height: '100vh' }}>
                <div className="col-md-6 text-center">
                    <h2 className="mb-4">Ajouter un Besoin</h2>
                    <p className="lead mb-5">Veuillez choisir une ressource</p>
                    <div className="d-flex justify-content-center">
                        <Link to="/ajouter-imprimante" style={{ marginRight: '20px' }} className="btn btn-primary me-3">Ajouter Imprimante</Link>
                        <Link to="/ajouter-ordinateur" style={{ marginLeft: '20px' }} className="btn btn-warning">Ajouter Ordinateur</Link>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default AddNeed;
