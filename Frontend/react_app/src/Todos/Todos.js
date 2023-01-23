import React, {useState} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import NoteBook from "./NoteBook/NoteBook";
import Note from "./Note/Note";
import NoteEditor from "./NoteEditor/NoteEditor";

function Todos(){
    const [notes, setNotes] = useState([]);

    const HandleNoteBookSelection = (id) => {
        fetch("http://localhost:5017/api/Notes/GetNotesByNoteBookId?noteBookId=" + id)
            .then(res => res.json())
            .then(
                (result) => {
                    setNotes(result)
                },
                (error) => {
                    console.log(error.message())
                }
            );
    }

    return(
        <div className="container-fluid">
            <div className="row">
                <div className="col-2">
                    <NoteBook HandleNoteBookSelection={HandleNoteBookSelection}/>
                </div>
                <div className="col-2">
                    <ul className="list-group">
                        <Note notes={notes} />
                    </ul>
                </div>
                <div className="col-8">
                    <NoteEditor/>
                </div>
            </div>
        </div>
    );
}

export default Todos;