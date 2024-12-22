import React, { useState, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';
import '../css/style.css'

function RessourceBesoinDetail() {
  const { IdB, IdR } = useParams();
  const [besoins, setBesoins] = useState([]);
  const [selectedBesoin, setSelectedBesoin] = useState(null);

  useEffect(() => {
    fetch('https://localhost:7251/api/ChefDepartements/besoins/1')
      .then(response => response.json())
      .then(data => setBesoins(data))
      .catch(error => console.error('Error fetching besoins:', error));
  }, []);

  useEffect(() => {
    if (besoins.length > 0) {
      const matchingBesoin = besoins.find(besoin => besoin.id === parseInt(IdR));
      setSelectedBesoin(matchingBesoin);
    }
  }, [IdR, besoins]);

  return (
    <div className="container">
      <h1>Details for Resource ID: {IdR}</h1>
      {selectedBesoin && (
        <div>
          {selectedBesoin.ressourceType === 'Imprimante' && (
            <div>
              <h4>Détails Imprimante</h4>
              <hr />
              <dl>
                <dt>Marque</dt>
                <dd>{selectedBesoin.marque}</dd>
                <dt>Résolution</dt>
                <dd>{selectedBesoin.resolution}</dd>
                <dt>Vitesse</dt>
                <dd>{selectedBesoin.vitesse}</dd>
              </dl>
              <p>
                <Link to={`/Responsable/liste-appel-offers/${IdB}`} className="btn btn-primary">Back to List</Link>
              </p>
            </div>
          )}
          {selectedBesoin.ressourceType === 'Ordinateur' && (
            <div>
              <h4>Détails Ordinateur</h4>
              <hr />
              <dl>
                <dt>CPU</dt>
                <dd>{selectedBesoin.cpu}</dd>
                <dt>Disque Dur</dt>
                <dd>{selectedBesoin.disqueDur}</dd>
                <dt>Écran</dt>
                <dd>{selectedBesoin.ecran}</dd>
                <dt>Marque</dt>
                <dd>{selectedBesoin.marque}</dd>
                <dt>Ram</dt>
                <dd>{selectedBesoin.ram}</dd>
              </dl>
              <p>
                <Link to={`/Responsable/liste-appel-offers/${IdB}`} className="btn btn-primary">Back to List</Link>
              </p>
            </div>
          )}
        </div>
      )}
    </div>
  );
}

export default RessourceBesoinDetail;
