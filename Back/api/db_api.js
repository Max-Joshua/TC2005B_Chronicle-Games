"use strict"

import express from 'express'
import mysql from 'mysql'
import fs from 'fs'

const app = express();
const port = 5000;

app.use(express.json());

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

app.use('/assets', express.static('./html/assets'))

app.use('/html', express.static('./html'))

function connectToDB()
{
    try{
        return mysql.createConnection({host:'localhost', user:'Joshua', password:'Amac@_01', database:'rumbleoftheforest'});
    }
    catch(error)
    {
        console.log(error);
    }   
}

app.get('/', (request,response)=>{
    fs.readFile('./html/score.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});




app.get('/api/user_info', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from user_info', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/statistics', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from statistics', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/score_enemies', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from score_enemies', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/score', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from score', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/score_notes', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from score_notes', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/top_high_scores', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_high_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.get('/api/notes_stats', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from notes_stats', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});



app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});








// app.post('/api/top_high_scores', (request, response)=>{

//     try{
//         console.log(request.headers);

//         let connection = connectToDB();
//         connection.connect();
//         console.log(request.body);
//         const query = connection.query('insert into top_high_scores set ?', request.body ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data inserted correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.post('/api/user_info', (request, response)=>{

//     try{
//         console.log(request.headers);

//         let connection = connectToDB();
//         connection.connect();
//         console.log(request.body);
//         const query = connection.query('insert into user_info set ?', request.body ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data inserted correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.put('/api/user_info', (request, response)=>{
//     try{
//         let connection = connectToDB();
//         connection.connect();

//         const query = connection.query('update user_info set name = ?, mail = ?, age = ?, country = ? where id_user_info= ?', [request.body['name'], request.body['mail'], request.body['age'], request.body['country'], request.body['userID']] ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data updated correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.delete('/api/user_info', (request, response)=>{
//     try
//     {
//         let connection = connectToDB();
//         connection.connect();

//         const query = connection.query('delete from user_info where id_user_info= ?', [request.body['userID']] ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data deleted correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// })
