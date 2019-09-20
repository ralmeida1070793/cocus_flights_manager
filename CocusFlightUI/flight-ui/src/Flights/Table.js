import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
class Table extends Component {
    constructor(props) {
        super(props);
    }

    DeleteFlight= () =>{
        axios.delete('https://localhost:44356/api/flights/'+this.props.obj.id)
            .then(res => {
                window.location.reload()
            })
    }
    render() {
        return (
            <tr>
                <td>
                    {this.props.obj.departure.name}
                </td>
                <td>
                    {this.props.obj.destination.name}
                </td>
                <td>
                    <Link to={"/Flights/"+this.props.obj.id} className="btn btn-success">Details</Link>
                </td>
                <td>
                    <Link to={"/Flights/edit/"+this.props.obj.id} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button type="button" onClick={this.DeleteFlight} className="btn btn-danger">Delete</button>
                </td>
            </tr>
        );
    }
}

export default Table;