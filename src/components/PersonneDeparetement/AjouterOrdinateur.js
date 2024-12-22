import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import '../css/style.css'

function AddComputer() {
    const [quantite, setQuantite] = useState('');
    const [cpu, setCpu] = useState('');
    const [disqueDur, setDisqueDur] = useState('');
    const [ecran, setEcran] = useState('');
    const [marque, setMarque] = useState('');
    const [ram, setRam] = useState('');
    const [idPerson, setIdPerson] = useState('');
    const [msg, setMsg] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        const url = `https://localhost:7251/api/PersonneDepartements/ajouter/ordinateur/${quantite}/${cpu}/${disqueDur}/${ecran}/${marque}/${ram}/${idPerson}`;

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                setMsg('Échec de l\'ajout de l\'ordinateur');
            } else {
                setMsg('Ordinateur ajouté avec succès');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            setMsg('Erreur lors de l\'ajout de l\'ordinateur');
        });
    };

    return (
        <div className="container">
            <h2 className="msg">Ajouter un Ordinateur</h2>
            <br />
            <div className="card border-left-light shadow h-100 py-2">
                <div className="card-body">
                    <form onSubmit={handleSubmit}>
                        <div className="form-group">
                            <label className="control-label">Quantité</label>
                            <input
                                type="text"
                                name="quantite"
                                value={quantite}
                                onChange={(e) => setQuantite(e.target.value)}
                                className="input"
                                placeholder="Quantité"
                            />
                        </div>

                        <div className="form-row">
                            <div className="form-group col-md-6">
                                <label className="control-label">CPU</label>
                                <input
                                    type="text"
                                    name="cpu"
                                    value={cpu}
                                    onChange={(e) => setCpu(e.target.value)}
                                    className="input"
                                    placeholder="CPU"
                                />
                            </div>
                            <div className="form-group col-md-6">
                                <label className="control-label">Disque Dur</label>
                                <input
                                    type="text"
                                    name="disqueDur"
                                    value={disqueDur}
                                    onChange={(e) => setDisqueDur(e.target.value)}
                                    className="input"
                                    placeholder="Disque Dur"
                                />
                            </div>
                        </div>

                        <div className="form-group">
                            <label className="control-label">Écran</label>
                            <input
                                type="text"
                                name="ecran"
                                value={ecran}
                                onChange={(e) => setEcran(e.target.value)}
                                className="input"
                                placeholder="Écran"
                            />
                        </div>

                        <div className="form-group">
                            <label className="control-label">Marque</label>
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
                            <label className="control-label">RAM</label>
                            <input
                                type="text"
                                name="ram"
                                value={ram}
                                onChange={(e) => setRam(e.target.value)}
                                className="input"
                                placeholder="RAM"
                            />
                        </div>

                        <div className="form-group">
                            <label className="control-label">ID Person</label>
                            <input
                                type="text"
                                name="idPerson"
                                value={idPerson}
                                onChange={(e) => setIdPerson(e.target.value)}
                                className="input"
                                placeholder="ID Person"
                            />
                        </div>

                        <div className="form-group">
                            <Link to='/ajouter-besoin' style={{ marginRight: '20px' }}>Back to List</Link>
                            <input type="submit" value="Create" className="btn btn-primary" />
                        </div>
                    </form>
                    {msg && <p className="msg">{msg}</p>}
                </div>
            </div>
        </div>
    );
}

export default AddComputer;
