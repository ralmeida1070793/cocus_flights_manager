import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
class Table extends Component {
    constructor(props) {
        super(props);
    }

    DeleteAirport= () =>{
        axios.delete('https://localhost:44356/api/airports/'+this.props.obj.id)
            .then(res => {
                window.location.reload()
            })
    }
    render() {
        return (
            <tr>
                <td>
                    {this.props.obj.name}
                </td>
                <td>
                    {this.props.obj.latitude}
                </td>
                <td>
                    {this.props.obj.longitude}
                </td>
                <td>
                    <Link to={"/Airports/edit/"+this.props.obj.id} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button type="button" onClick={this.DeleteAirport} className="btn btn-danger">Delete</button>
                </td>
            </tr>
        );
    }
}

export default Table;