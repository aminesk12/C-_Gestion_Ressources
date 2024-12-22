import React, { useState, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';
import '../css/style.css'; // Import the styles

function ListeBesoinResponsable() {
  const { IdB } = useParams(); // Destructure IdB from useParams
  const [besoin, setSelectedBesoin] = useState(null);

  useEffect(() => {
    fetch('https://localhost:7251/api/ResponsableRessources/AppelOffresWithDetails')
      .then(response => response.json())
      .then(data => {
        findBesoin(data);
      })
      .catch(error => console.error('Error fetching besoins:', error));
  }, [IdB]);

  const findBesoin = (besoins) => {
    const found = besoins.find(besoin => besoin.id === parseInt(IdB));
    if (found) {
      setSelectedBesoin(found);
    } else {
      console.warn(`Besoin with IdB: ${IdB} not found`);
    }
  };

  return (
    <div className="container" style={{ marginLeft: '20%', marginRight: '20%' }}>
      
      <h2 className="h3 mb-0" style={{ color: '#144272' }}>Liste des Besoins du Responsable</h2>
      <br />
      <br />
      <div className="row">
        <form>
          <div className="col-xl-9 col-md-6 mb-4">
            <div className="card border-left-primary shadow h-100 py-2">
              <div className="card-body">
                <div className="row no-gutters align-items-center">
                  <table className="table">
                    <thead>
                      <tr>
                        <th>Quantite</th>
                        <th>Ressource</th>
                      </tr>
                    </thead>
                    <tbody>
                      {besoin && besoin.besoins ? (
                        besoin.besoins.map(item => (
                          <tr key={item.id}>
                            <td>{item.quantite}</td>
                            <td>
                              <Link to={`/Responsable/liste-appel-offers/${IdB}/${item.id}`}>
                                Afficher
                              </Link>
                            </td>
                          </tr>
                        ))
                      ) : (
                        <tr>
                          <td colSpan="2" className="no-items">No items found</td>
                        </tr>
                      )}
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </form>
        <div className="mb-4">
        <Link to="/Responsable/liste-appel-offers" className="btn btn-secondary">Back to List</Link>
      </div>
      </div>
    </div>
  );
}

export default ListeBesoinResponsable;
