import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import '../css/style.css';

const ListAppelOffreView = () => {
  const [appelsOffres, setAppelsOffres] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7251/api/Fournisseurs/AppelsOffresWithDetails');
        if (!response.ok) {
          throw new Error('Failed to fetch appels d\'offres');
        }
        const data = await response.json();
        setAppelsOffres(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) {
    return <div>Chargement des appels d'offres...</div>;
  }

  if (error) {
    return <div>Erreur: {error}</div>;
  }

  return (
    <div className="container">
      <h2 className="h3 mb-0" style={{ color: '#144272' }}>Liste des offers</h2>
      <br />
      <br />
      <div className="card border-left-primary shadow h-100 py-2">
        <div className="card-body">
          <div className="row no-gutters align-items-center">
            <table className="table">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Besoins</th>
                </tr>
              </thead>
              <tbody>
                {appelsOffres.map(item => (
                  <tr key={item.id}>
                    <td>{item.date}</td>
                    <td>
                      <Link to={`/liste-appel-offers/afficher-besoin/${item.id}`} className="btn btn-primary">Afficher Besoin</Link>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ListAppelOffreView;
