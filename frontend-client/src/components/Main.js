require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';
import CarsComponent from './CarsComponent';
import ClientsComponent from './ClientsComponent';

class AppComponent extends React.Component {
  render() {
    return (
      <Router>
        <div className="navbar">
          <p>
            <Link to="/"> Home </Link>
          </p>
          <p>
            <Link to="/cars"> Cars </Link>
          </p>
          <p>
            <Link to="/clients"> Clients </Link>
          </p>
          <Route exact path="/index.html" component={AppComponent} />
          <Route path="/cars" component={CarsComponent} />
          <Route path="/clients" component={ClientsComponent} />
        </div>
      </Router>
    );
  }
}


export default AppComponent;
