import React from 'react';
import { Link } from 'react-router-dom';

function OrdinateurDetails({ cpu, disqueDur, ecran, marque, ram }) {
    return (
        <div>
            <h4>Détails Ordinateur</h4>
            <hr />
            <dl className="dropdown-list-image">
                <dl className="dl-horizontal">
                    <dt>CPU</dt>
                    <dd>{cpu}</dd>
                    <dt>Disque Dur</dt>
                    <dd>{disqueDur}</dd>
                    <dt>Écran</dt>
                    <dd>{ecran}</dd>
                    <dt>Marque</dt>
                    <dd>{marque}</dd>
                    <dt>Ram</dt>
                    <dd>{ram}</dd>
                </dl>
            </dl>
            <p>
                <Link to="/ListeBesoinsDep" className="btn btn-primary">Back to List</Link>
            </p>
        </div>
    );
}

export default OrdinateurDetails;
