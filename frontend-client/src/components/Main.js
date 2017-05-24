'use strict';

import React from 'react';

let indexImage = require('../images/background.jpg');

class AppComponent extends React.Component {
  render() {
    return (
      <div className="index">
        <img src={indexImage} alt="index-image" />
      </div>
    );
  }
}


export default AppComponent;
