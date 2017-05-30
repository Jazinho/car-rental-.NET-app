'use strict';

import React from 'react';

require('styles//Clients.css');

class ClientsComponent extends React.Component {
  render() {
    return (
      <div className="clients-component">
        <p> Clients Clients CLients </p>
      </div>
    );
  }
}

ClientsComponent.displayName = 'ClientsComponent';

// Uncomment properties you need
// ClientsComponent.propTypes = {};
// ClientsComponent.defaultProps = {};

export default ClientsComponent;
