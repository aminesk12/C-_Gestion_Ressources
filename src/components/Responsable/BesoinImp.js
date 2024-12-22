import React from 'react';
import { Link } from 'react-router-dom';

function ImprimanteDetails({ marque, resolution, vitesse }) {
    return (
        <div>
            <h4>Détails Imprimante</h4>
            <hr />
            <dl>
                <dt>Marque</dt>
                <dd>{marque}</dd>
                <dt>Résolution</dt>
                <dd>{resolution}</dd>
                <dt>Vitesse</dt>
                <dd>{vitesse}</dd>
            </dl>
            <p>
                <Link to="/ListeBesoinsDep" className="btn btn-primary">Back to List</Link>
            </p>
        </div>
    );
}

export default ImprimanteDetails;
