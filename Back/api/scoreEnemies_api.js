"use strict"

import express from 'express'
import mysql from 'mysql'
import fs from 'fs'

const app = express();
const port = 5003;

app.use(express.json());

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

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
    fs.readFile('./html/score_enemies.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
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

app.post('/api/score_enemies', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into score_enemies set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

app.put('/api/score_enemies', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('update score_enemies set num_of_enemies = ? where id_score_enemies= ?', [request.body['num_of_enemies'], request.body['score_enemiesID']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data updated correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

app.delete('/api/score_enemies', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from score_enemies where id_score_enemies= ?', [request.body['score_enemiesID']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
})

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});