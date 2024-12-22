import React, { useEffect, useState } from 'react';
import { Link, useParams } from "react-router-dom";

const AfficherBesoinsF = () => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const { IdB } = useParams(); // Destructure IdB from useParams
  const [besoin, setSelectedBesoin] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7251/api/Fournisseurs/AppelsOffresWithDetails');
        if (!response.ok) {
          throw new Error('Failed to fetch besoins');
        }
        const data = await response.json();
        findBesoin(data);
      } catch (err) {
        console.error('Error fetching besoins:', err);
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [IdB]);

  const findBesoin = (besoins) => {
    const found = besoins.find(besoin => besoin.id === parseInt(IdB));
    if (found) {
      setSelectedBesoin(found.besoins);
    } else {
      console.warn(`Besoin with IdB: ${IdB} not found`);
    }
  };

  if (loading) {
    return <div>Chargement des besoins...</div>;
  }

  if (error) {
    return <div>Erreur: {error}</div>;
  }

  return (
    <div>
      <h2>Afficher Besoins</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Quantité</th>
            <th>Ressource</th>
            <th>Offre</th>
          </tr>
        </thead>
        <tbody>
          {besoin.length > 0 ? (
            besoin.map((item, index) => (
              <tr key={index}>
                <td>{item.quantite}</td>
                <td><Link to={`/liste-appel-offers/afficher-besoin/${IdB}/Detail/${item.id}`}>Detail Ressources</Link></td>
                <td><Link to={`/liste-appel-offers/afficher-besoin/create-offer`}>Proposer mon Offre</Link></td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="3">Aucun besoin trouvé</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default AfficherBesoinsF;
