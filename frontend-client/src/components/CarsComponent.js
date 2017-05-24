'use strict';

import React from 'react';

require('styles//Cars.css');

class CarsComponent extends React.Component {
  render() {
    return (
      <div className="cars-component">
        <p>Cars Cars Cars</p>
      </div>
    );
  }
}

CarsComponent.displayName = 'CarsComponent';

// Uncomment properties you need
// CarsComponent.propTypes = {};
// CarsComponent.defaultProps = {};

export default CarsComponent;
