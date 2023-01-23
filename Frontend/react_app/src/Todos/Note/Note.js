import React, {useState} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

function Note(props){
    if(props.notes.length === 0) {
        return (
            <div>
                <ul className="list-group">
                        <li className="list-group-item">
                            Here empty...
                        </li>
                </ul>
            </div>
        );
    }

    return (
        <div>
            <ul className="list-group">
                {props.notes.map(item => (
                    <li className="list-group-item" key={item.whenAdded} >
                        {item.noteTitle}
                    </li>
                ))}
            </ul>
        </div>
    );

}

export default Note;