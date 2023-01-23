import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';


function NoteBook({HandleNoteBookSelection}){
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [notebooks, setNotebooks] = useState([]);
    const [selectedNotebook, setSelectedNotebook] = useState(0);
    const [post, setPost] = useState([])

    const UpdateSelectedNotebook = (id) => {
        setSelectedNotebook(id);
        HandleNoteBookSelection(id);
    }

    useEffect(() => { //it is here very interesting costil TODO
       fetch("http://localhost:5017/api/NoteBooks", {
           method: "POST",
           headers: {
               Accept: 'application/json',
               'Content-Type': 'application/json',
           },
           body: JSON.stringify({
                noteBookTitle: "TestFromReact"
           }),
       })
           .then(res => res.json())
           .then((result) => {
               console.log(result)
           })
    });

    useEffect(() => {
        fetch("http://localhost:5017/api/NoteBooks")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setNotebooks(result);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    }, []);

    if (error) {
        return <div>Ошибка: {error.message}</div>;
    }  if (!isLoaded) {
        return <div>Загрузка...</div>;
    }
    return (
        <div>
            <ul className="list-group">
                {notebooks.map(item => (
                    <li className ={`list-group-item ${selectedNotebook === item.id ? "active" : ""}`}
                        key={item.id}
                        onClick={() => UpdateSelectedNotebook(item.id)} >
                        {item.noteBookTitle}
                    </li>
                ))}
            </ul>
            <button type="button" className="btn btn-secondary" onClick={() => AddNotebook(notebooks)}>Add NoteBook</button>
            <button type="button" className="btn btn-danger">Delete Notebook</button>
        </div>
    );
}

function AddNotebook(notebooks){


}

export default NoteBook;