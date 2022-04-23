import mysql from 'mysql'
import { getRandomName, getRandomStatistic, getRandomScore, getRandomScoreEnemies } from './fetch_random.js'

function randomString(length) 
{
    let result = ''
    let characters= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
    let charactersLength = characters.length;

    for (let i = 0; i < length; i++ ) 
      result += characters.charAt(Math.floor(Math.random() * charactersLength))
   
   return result
}

const names = await getRandomName(20)
const pointer = await getRandomStatistic(20)
const scores = await getRandomScore(20)
const scoresE = await getRandomScoreEnemies(20)

const connection = mysql.createConnection(
    {
        host:'localhost', 
        user:'Joshua', 
        password:'Amac@_01', 
        database: 'rumbleoftheforest'
    })

connection.connect(error=>
    {
        if (error) console.log(error)
        console.log('Connected to mysql!')
    })

for(const n of names)
{
    let [name, mail, age, country] = n.split(" ")
    const user_info = { name: name, mail: mail, age: age, country: country}

    connection.query('insert into user_info set ?', user_info, (error, rows, fields)=> 
    {
        if(error) console.log(error)
        console.log(`Added ${name} ${mail} ${age} ${country} successfully!`)
    })
}

for(const s of pointer)
{
    let [accuracy, game_time, deaths] = s.split(" ")
    const statistics = {accuracy: accuracy, game_time: game_time, deaths: deaths}

    connection.query('insert into statistics set ?', statistics, (error, rows, fields)=> 
    {
        if(error) console.log(error)
        console.log(`Added ${accuracy} ${game_time} ${deaths} successfully!`)
    })
}

for(const sc of scores)
{
    let [total_score, lost_life, damage_taken, damage_inflicted] = sc.split(" ")
    const score = {total_score: total_score, lost_life: lost_life, damage_taken: damage_taken, damage_inflicted: damage_inflicted}

    connection.query('insert into score set ?', score, (error, rows, fields)=> 
    {
        if(error) console.log(error)
        console.log(`Added ${total_score} ${lost_life} ${damage_taken} ${damage_inflicted} successfully!`)
    })
}

for(const se of scoresE)
{
    let [num_of_enemies] = se.split(" ")
    const score_enemies = {num_of_enemies: num_of_enemies}

    connection.query('insert into score_enemies set ?', score_enemies, (error, rows, fields)=> 
    {
        if(error) console.log(error)
        console.log(`Added ${num_of_enemies} successfully!`)
    })
}

connection.end(error=>
    {
        if(error) console.log(error)
        console.log("Connection closed successfully!")
    })