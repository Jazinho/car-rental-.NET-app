require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';

let backgroundImage = require('../images/background.jpg');

class AppComponent extends React.Component {
  render() {
    return (
      <div className="index">
        <img src={backgroundImage} alt="backgroundImage" />
      </div>
    );
  }
}

AppComponent.defaultProps = {
};

export default AppComponent;
