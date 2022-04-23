// Using the module 'node-fetch' to get the functionality of the fetch api: https://github.com/node-fetch/node-fetch
// npm install node-fetch

import fetch from 'node-fetch'


async function fetchData(url)
{
    try
    {
        const response = await fetch(url)
    
        if(response.ok)
            return response.json()
        else
            console.log(`HTTP Error: ${response.status}`)
    }
    catch(error)
    {
        console.log(error)
    }
}

function pickRandomElement(list) 
{
    return list[Math.floor(Math.random() * list.length)];
}

async function getRandomName(amount=1)
{
    if(amount<=0) amount = 1
    
    const base_url = 'https://www.randomlists.com/data/names-'
    
    const male_names = await fetchData(base_url + 'male.json')
    const female_names = await fetchData(base_url + 'female.json')
    const countries = [ 
        'Afghanistan',
        'Åland Islands',
        'Albania',
        'Algeria',
        'American Samoa',
        'AndorrA',
        'Angola',
        'Anguilla',
        'Antarctica',
        'Antigua and Barbuda',
        'Argentina',
        'Armenia',
        'Aruba',
        'Australia',
        'Austria',
        'Azerbaijan',
        'Bahamas',
        'Bahrain',
        'Bangladesh',
        'Barbados',
        'Belarus',
        'Belgium',
        'Belize',
        'Benin',
        'Bermuda',
        'Bhutan',
        'Bolivia',
        'Bosnia and Herzegovina',
        'Botswana',
        'Bouvet Island',
        'Brazil',
        'British Indian Ocean Territory',
        'Brunei Darussalam',
        'Bulgaria',
        'Burkina Faso',
        'Burundi',
        'Cambodia',
        'Cameroon',
        'Canada',
        'Cape Verde',
        'Cayman Islands',
        'Central African Republic',
        'Chad',
        'Chile',
        'China',
        'Christmas Island',
        'Cocos (Keeling) Islands',
        'Colombia',
        'Comoros',
        'Congo',
        'Congo, The Democratic Republic of the',
        'Cook Islands',
        'Costa Rica',
        'Cote D\'Ivoire',
        'Croatia',
        'Cuba',
        'Cyprus',
        'Czech Republic',
        'Denmark',
        'Djibouti',
        'Dominica',
        'Dominican Republic',
        'Ecuador',
        'Egypt',
        'El Salvador',
        'Equatorial Guinea',
        'Eritrea',
        'Estonia',
        'Ethiopia',
        'Falkland Islands (Malvinas)',
        'Faroe Islands',
        'Fiji',
        'Finland',
        'France',
        'French Guiana',
        'French Polynesia',
        'French Southern Territories',
        'Gabon',
        'Gambia',
        'Georgia',
        'Germany',
        'Ghana',
        'Gibraltar',
        'Greece',
        'Greenland',
        'Grenada',
        'Guadeloupe',
        'Guam',
        'Guatemala',
        'Guernsey',
        'Guinea',
        'Guinea-Bissau',
        'Guyana',
        'Haiti',
        'Heard Island and Mcdonald Islands',
        'Holy See (Vatican City State)',
        'Honduras',
        'Hong Kong',
        'Hungary',
        'Iceland',
        'India',
        'Indonesia',
        'Iran, Islamic Republic Of',
        'Iraq',
        'Ireland',
        'Isle of Man',
        'Israel',
        'Italy',
        'Jamaica',
        'Japan',
        'Jersey',
        'Jordan',
        'Kazakhstan',
        'Kenya',
        'Kiribati',
        'Korea, Democratic People\'S Republic of',
        'Korea, Republic of',
        'Kuwait',
        'Kyrgyzstan',
        'Lao People\'S Democratic Republic',
        'Latvia',
        'Lebanon',
        'Lesotho',
        'Liberia',
        'Libyan Arab Jamahiriya',
        'Liechtenstein',
        'Lithuania',
        'Luxembourg',
        'Macao',
        'Macedonia, The Former Yugoslav Republic of',
        'Madagascar',
        'Malawi',
        'Malaysia',
        'Maldives',
        'Mali',
        'Malta',
        'Marshall Islands',
        'Martinique',
        'Mauritania',
        'Mauritius',
        'Mayotte',
        'Mexico',
        'Micronesia, Federated States of',
        'Moldova, Republic of',
        'Monaco',
        'Mongolia',
        'Montserrat',
        'Morocco',
        'Mozambique',
        'Myanmar',
        'Namibia',
        'Nauru',
        'Nepal',
        'Netherlands',
        'Netherlands Antilles',
        'New Caledonia',
        'New Zealand',
        'Nicaragua',
        'Niger',
        'Nigeria',
        'Niue',
        'Norfolk Island',
        'Northern Mariana Islands',
        'Norway',
        'Oman',
        'Pakistan',
        'Palau',
        'Palestinian Territory, Occupied',
        'Panama',
        'Papua New Guinea',
        'Paraguay',
        'Peru',
        'Philippines',
        'Pitcairn',
        'Poland',
        'Portugal',
        'Puerto Rico',
        'Qatar',
        'Reunion',
        'Romania',
        'Russian Federation',
        'RWANDA',
        'Saint Helena',
        'Saint Kitts and Nevis',
        'Saint Lucia',
        'Saint Pierre and Miquelon',
        'Saint Vincent and the Grenadines',
      ]

    // Alternative for calling multiple promises:
    // const response = await Promise.all([
    //     fetchData(base_url + 'male.json'),
    //     fetchData(base_url + 'female.json'),
    //     fetchData(base_url + 'surnames.json')
    // ])

    // const [male_names, female_names, surnames] = response;

    const names = male_names.data.concat(female_names.data)

    let name_list = []

    for(let i =0; i< amount; i++)
    {
        let name = pickRandomElement(names)
        let mail = `${name}${Math.floor(Math.random() * 1000)}@gmail.com`
        let age = Math.floor((Math.random() * 50) + 20)
        let country = pickRandomElement(countries)


        name_list.push(`${name} ${mail} ${age} ${country}`)
    }

    return name_list
}

async function getRandomStatistic(amount=1)
{    
    if(amount<=0) amount = 1

    let statistics_list = []

    for(let i =0; i< amount; i++)
    {
        let accuracy = (Math.random() * 100)
        let game_time = Math.floor(Math.random() * 500)
        let deaths = Math.floor(Math.random() * 250)

        statistics_list.push(`${accuracy} ${game_time} ${deaths}`)
    }

    return statistics_list
}

async function getRandomScore(amount=1)
{    
    if(amount<=0) amount = 1

    let score_list = []

    for(let i =0; i< amount; i++)
    {
        let total_score = (Math.random() * 1000000)
        let lost_life = Math.floor(Math.random() * 100)
        let damage_taken = Math.floor(Math.random() * 750)
        let damage_inflicted = Math.floor(Math.random() * 2000)

        score_list.push(`${total_score} ${lost_life} ${damage_taken} ${damage_inflicted}`)
    }

    return score_list
}

async function getRandomScoreEnemies(amount=1)
{    
    if(amount<=0) amount = 1

    let scoreEnemies_list = []

    for(let i =0; i< amount; i++)
    {
        let num_of_enemies = (Math.random() * 1000)
        scoreEnemies_list.push(`${num_of_enemies}`)
    }

    return scoreEnemies_list
}

export {getRandomName, getRandomStatistic, getRandomScore, getRandomScoreEnemies}