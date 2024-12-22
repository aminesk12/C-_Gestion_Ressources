import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import '../css/style.css';

function AddPrinter() {
    const [quantite, setQuantite] = useState('');
    const [marque, setMarque] = useState('');
    const [resolution, setResolution] = useState('');
    const [vitesse, setVitesse] = useState('');
    const [idPerson, setIdPerson] = useState('');
    const [msg, setMsg] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        const url = `https://localhost:7251/api/PersonneDepartements/ajouter/imprimante/${quantite}/${marque}/${resolution}/${vitesse}/${idPerson}`;
        
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                setMsg('Échec de l\'ajout de l\'imprimante');
            } else {
                setMsg('Imprimante ajoutée avec succès');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            setMsg('Erreur lors de l\'ajout de l\'imprimante');
        });
    };

    return (
        <div className="container">
            <h2 className="msg">Ajouter une Imprimante</h2>
            <br />
            <div className="card border-left-light shadow h-100 py-2">
                <div className="card-body">
                    <form onSubmit={handleSubmit}>
                        <div className="form-group">
                            <label className="label">Quantité</label>
                            <input
                                type="text"
                                name="quantite"
                                value={quantite}
                                onChange={(e) => setQuantite(e.target.value)}
                                className="input"
                                placeholder="Quantité"
                            />
                        </div>

                        <div className="form-group">
                            <label className="label">Marque</label>
                            <input
                                type="text"
                                name="marque"
                                value={marque}
                                onChange={(e) => setMarque(e.target.value)}
                                className="input"
                                placeholder="Marque"
                            />
                        </div>

                        <div className="form-group">
                            <label className="label">Résolution</label>
                            <input
                                type="text"
                                name="resolution"
                                value={resolution}
                                onChange={(e) => setResolution(e.target.value)}
                                className="input"
                                placeholder="Résolution"
                            />
                        </div>

                        <div className="form-group">
                            <label className="label">Vitesse</label>
                            <input
                                type="text"
                                name="vitesse"
                                value={vitesse}
                                onChange={(e) => setVitesse(e.target.value)}
                                className="input"
                                placeholder="Vitesse"
                            />
                        </div>

                        <div className="form-group">
                            <label className="label">ID Personne</label>
                            <input
                                type="text"
                                name="idPerson"
                                value={idPerson}
                                onChange={(e) => setIdPerson(e.target.value)}
                                className="input"
                                placeholder="ID Personne"
                            />
                        </div>

                        <div className="form-group">
                            <Link to='/ajouter-besoin'style={{ marginRight: '20px' }}>Back to List</Link>
                            <button type="submit" className="btn btn-primary">Create</button>
                        </div>
                    </form>
                    {msg && <p className="msg">{msg}</p>}
                </div>
            </div>
        </div>
    );
}

export default AddPrinter;
