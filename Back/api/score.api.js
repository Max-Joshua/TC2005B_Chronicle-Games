"use strict"

import express from 'express'
import mysql from 'mysql'
import fs from 'fs'

const app = express();
const port = 5002;

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
    fs.readFile('./html/score.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
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

app.post('/api/score', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into score set ?', request.body ,(error, results, fields)=>{
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

app.put('/api/score', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('update score set total_score = ?, lost_life = ?, damage_taken = ?, damage_inflicted = ? where id_score= ?', [request.body['total_score'], request.body['lost_life'], request.body['damage_taken'], request.body['damage_inflicted'], request.body['scoreID']] ,(error, results, fields)=>{
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

app.delete('/api/score', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from score where id_score= ?', [request.body['scoreID']] ,(error, results, fields)=>{
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