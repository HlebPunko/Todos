import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import NoteBook from "./NoteBook/NoteBook";
import Note from "./Note/Note";

function Todos(){
    return(
        <div className="container-fluid">
            <div className="row">
                <div className="col-2">
                    <NoteBook />
                </div>
                <div className="col-2">
                    List notes in notebook
                </div>
                <div className="col-8">
                    <Note />
                </div>

            </div>
        </div>
    );
}

export default Todos;