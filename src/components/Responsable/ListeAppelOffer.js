import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import '../css/style.css'
const ListeAppelsOffres = () => {
  const [appelsOffres, setAppelsOffres] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7251/api/ResponsableRessources/AppelOffresWithDetails');
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

  const handleValidation = async (id, action) => {
    try {
      const status = action; // Convert action to boolean
      console.log("STATUS : "+ status
      )
      const response = await fetch(`https://localhost:7251/api/ResponsableRessources/latest/${status}`, {
        method: 'PUT',
      });
  
      if (!response.ok) {
        throw new Error('Failed to update appel d\'offre');
      }
  
      if (response.status === 204) {
        setAppelsOffres(appelsOffres.map((offre) =>
          offre.id === id ? { ...offre, sendStatus: status } : offre
        ));
      } else {
        const updatedData = await response.json();
        setAppelsOffres(appelsOffres.map((offre) => (offre.id === id ? updatedData : offre)));
      }
    } catch (err) {
      console.error('Error validating appel d\'offre:', err);
    }
  };
  
  if (loading) {
    return <div>Chargement des appels d'offres...</div>;
  }

  if (error) {
    return <div>Erreur: {error}</div>;
  }

  return (
    <div style={{ marginLeft: '20%', marginRight: '20%' }}>
      <h2 className="h3 mb-0" style={{ color: '#144272' }}>Liste des appels d'offres</h2>
      <br />
      <br />
      <div className="card border-left-primary shadow h-100 py-2">
        <div className="card-body">
          <div className="row no-gutters align-items-center">
            <table className="table">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Besoin</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {appelsOffres.map((item) => (
                  <tr key={item.id}>
                    <td>{item.date}</td>
                    <td>
                      <Link to={`/Responsable/liste-appel-offers/${item.id}`}>Besoin</Link>
                    </td>
                    {item.sendStatus ? (
                        <td className={item.sendStatus ? 'text-success' : 'text-failed'}>
                          {!item.sendStatus ? 'Appel d\'offre validé' : 'Appel d\'offre rejeté'}
                        </td>
                      ) : (
                        <td>
                          <input type='submit' onClick={() => handleValidation(item.id, 'true')} value='Valider' />
                          <input type='submit' onClick={() => handleValidation(item.id, 'false')} value='Rejeter' />
                        </td>
                      )}

                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ListeAppelsOffres;
