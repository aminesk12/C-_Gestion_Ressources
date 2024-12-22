import React from 'react';
import { Link } from 'react-router-dom';

function Envoyer() {
    return (
        <div>
            <br />
            <br />
            <br />
            <br />
            <div className="card border-left-secondary shadow h-100 py-2">
                <div className="card-body">
                    <div className="row no-gutters align-items-center">
                        <br />
                        <br />
                        <br />
                        <h2 className="text-primary align-items-center">
                            La demande est envoyée au Responsable
                        </h2>
                    </div>
                    <br />
                    <br />
                    <Link to="/liste-Besoins" className="btn btn-primary">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default Envoyer;
