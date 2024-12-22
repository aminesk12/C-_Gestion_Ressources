import React from 'react';
import { Link } from 'react-router-dom';

function ErrorEnvoyer() {
    return (
        <div>
            <br />
            <br />
            <br />
            <br />
            <div className="card border-left-danger shadow h-100 py-2">
                <div className="card-body">
                    <div className="row no-gutters align-items-center">
                        <br />
                        <br />
                        <br />
                        <h2 className="text-danger align-items-center">
                            Error d'envoie des Besoins au Responsable "Budget Insuffisant"
                        </h2>
                    </div>
                    <br />
                    <br />
                    <Link to="/ListeBesoinsDep" className="btn btn-danger">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default ErrorEnvoyer;
