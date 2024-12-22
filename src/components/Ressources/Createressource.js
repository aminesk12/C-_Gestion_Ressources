import React, { useState } from 'react';

const CreateRessource = () => {
  const [code, setCode] = useState('');
  const [affectationStatus, setAffectationStatus] = useState(false);

  const handleSubmit = (event) => {
    event.preventDefault();
    // Handle form submission here
  };

  return (
    <div>
      <h2>Create</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-horizontal">
          <h4>Ressource</h4>
          <hr />
          <div className="form-group">
            <label htmlFor="code" className="control-label col-md-2">Code</label>
            <div className="col-md-10">
              <input
                type="text"
                id="code"
                className="form-control"
                value={code}
                onChange={(e) => setCode(e.target.value)}
              />
            </div>
          </div>

          <div className="form-group">
            <label htmlFor="affectationStatus" className="control-label col-md-2">AffectationStatus</label>
            <div className="col-md-10">
              <div className="checkbox">
                <input
                  type="checkbox"
                  id="affectationStatus"
                  checked={affectationStatus}
                  onChange={(e) => setAffectationStatus(e.target.checked)}
                />
              </div>
            </div>
          </div>

          <div className="form-group">
            <div className="col-md-offset-2 col-md-10">
              <button type="submit" className="btn btn-default">Create</button>
            </div>
          </div>
        </div>
      </form>

      <div>
        {/* Back to List link */}
      </div>
    </div>
  );
}

export default CreateRessource;
