import React from 'react';
import AddAeroplane from './Aeroplanes/AddAeroplane';
import AeroplanesList from './Aeroplanes/AeroplanesList';
import EditAeroplane from './Aeroplanes/EditAeroplane';
import AddAirport from './Airports/AddAirport';
import AirportsList from './Airports/AirportsList';
import EditAirport from './Airports/EditAirport';
import AddFlight from './Flights/AddFlight';
import FlightsList from './Flights/FlightsList';
import EditFlight from './Flights/EditFlight';
import FlightDetails from './Flights/FlightDetails';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import './App.css';
function App() {
    return (
        <Router>
            <div className="container">
                <nav className="navbar navbar-expand-lg navheader">
                    <div className="collapse navbar-collapse" >
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item">
                                <Link to={'/Aeroplanes/New'} className="nav-link">Add Aeroplane</Link>
                            </li>
                            <li className="nav-item">
                                <Link to={'/Aeroplanes'} className="nav-link">Aeroplanes List</Link>
                            </li>
                            <li className="nav-item">
                                <Link to={'/Airports/New'} className="nav-link">Add Airport</Link>
                            </li>
                            <li className="nav-item">
                                <Link to={'/Airports'} className="nav-link">Airports List</Link>
                            </li>

                            <li className="nav-item">
                                <Link to={'/Flights/New'} className="nav-link">Add Flight</Link>
                            </li>
                            <li className="nav-item">
                                <Link to={'/Flights'} className="nav-link">Flights List</Link>
                            </li>
                        </ul>
                    </div>
                </nav> <br />
                <Switch>
                    <Route exact path='/Aeroplanes/New' component={AddAeroplane} />
                    <Route path='/Aeroplanes/edit/:id' component={EditAeroplane} />
                    <Route path='/Aeroplanes' component={AeroplanesList} />
                    <Route exact path='/Airports/New' component={AddAirport} />
                    <Route path='/Airports/edit/:id' component={EditAirport} />
                    <Route path='/Airports' component={AirportsList} />

                    <Route exact path='/Flights/New' component={AddFlight} />
                    <Route path='/Flights/edit/:id' component={EditFlight} />
                    <Route path='/Flights/:id' component={FlightDetails} />
                    <Route path='/Flights' component={FlightsList} />

                </Switch>
            </div>
        </Router>
    );
}

export default App;
