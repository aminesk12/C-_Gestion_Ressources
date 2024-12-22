import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import '../css/CreateOffer.css'

const CreateOffre = () => {
  const [prix, setPrix] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    const formData = {
      prix
    };
    const jsonData = JSON.stringify(formData);

    // Log the JSON data
    console.log('Submitted:', jsonData);
  };

  return (
    <div className="container create-offre-container">
      <h2 className="text-center mb-4">Create Offre</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group row">
          <label htmlFor="prix" className="col-md-2 col-form-label">Prix</label>
          <div className="col-md-10">
            <input
              type="number"
              id="prix"
              className="form-control"
              value={prix}
              onChange={(e) => setPrix(e.target.value)}
            />
          </div>
        </div>

        <div className="form-group row">
          <div className="col-md-10 offset-md-2">
            <button type="submit" className="btn btn-primary mr-2">Create</button>
            <Link to='/liste-appel-offers' className="btn btn-secondary">Back to List</Link>
          </div>
        </div>
      </form>
    </div>
  );
}

export default CreateOffre;
