import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import '../css/style.css';

function ListeBesoinDepartement() {
  const [besoins, setBesoins] = useState([]);
  const [budget, setBudget] = useState(0);
  const [departement, setDepartement] = useState('Département 1');
  const [msg, setMsg] = useState('');

  useEffect(() => {
    fetch('https://localhost:7251/api/ChefDepartements/besoins/1')
      .then(response => response.json())
      .then(data => setBesoins(data))
      .catch(error => console.error('Error fetching besoins:', error));

    setBudget('18000');
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();

    const url = 'https://localhost:7251/api/ChefDepartements/envoyerBesoins';

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ budget, departement, besoins })
    })
      .then(response => {
        if (response.ok) {
          return response.text(); // Handle string response
        } else {
          throw new Error('Network response was not ok.');
        }
      })
      .then(data => {
        if (data.includes("Les besoins ont été ajoutés à un nouvel appel d'offre.")) {
          setMsg("Les besoins ont été ajoutés à un nouvel appel d'offre.");
        } else {
          setMsg(data); // Set the exact error message from the backend
        }
      })
      .catch(error => {
        console.error('Error sending needs:', error);
        setMsg('Erreur lors de l\'envoi des besoins.');
      });
  };

  return (
    <div>
      <h2 className="h3 mb-0" style={{ color: '#144272' }}>
        Liste des Besoins du Département <b>{departement}</b>
      </h2>
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
                      {besoins.map(item => (
                        <tr key={item.id}>
                          <td>{item.quantite}</td>
                          <td>
                            <Link to={`/liste-Besoins/Ressource-Detail/${item.id}`}>afficher</Link>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
          <div className="col-xl-3 col-md-6 mb-4">
            <div className="card shadow py-2" style={{ backgroundColor: 'lightgrey' }}>
              <div className="justify-content-center my-2 btn btn-light">
                <button onClick={handleSubmit} className="btn btn-secondary">Create</button>
              </div>
            </div>
          </div>
        </form>
        {msg && <p>{msg}</p>}
      </div>
    </div>
  );
}

export default ListeBesoinDepartement;
