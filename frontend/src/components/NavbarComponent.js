require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';
import CarsComponent from './CarsComponent';
import ClientsComponent from './ClientsComponent';
import AppComponent from './Main';

require('styles//Navbar.css');

class NavbarComponent extends React.Component {
  render() {
    return (
		  <Router>
			<div className="navbar">
			  <ul>
				<li>
				  <Link to="/"> Home </Link>
				</li>
				<li>
				  <Link to="/cars"> Cars </Link>
				</li>
				<li>
				  <Link to="/clients"> Clients </Link>
				</li>
			  </ul>
			  <Route exact path="/" component={AppComponent} />
			  <Route path="/cars" component={CarsComponent} />
			  <Route path="/clients" component={ClientsComponent} />
			</div>
		  </Router>
    );
  }
}

NavbarComponent.displayName = 'NavbarComponent';

// Uncomment properties you need
// NavbarComponent.propTypes = {};
// NavbarComponent.defaultProps = {};

export default NavbarComponent;
