

async function setupChar()
{
    let response = await fetch('http://localhost:5000/api/notes_stats',{
        method: 'GET'
    })

    if(response.ok)
    {
        let results = await response.json()
    console.log(results)
    const data = {
        labels: [
          'Perfect',
          'Good',
          'Hit',
          'Missed'
        ],
        datasets: [{
          label: 'Acurrancy Percentage',
          data: [results.perfect_percentage, results.good_percentage, results.hit_percentage, results.missed_percentage],
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)'
          ],
          hoverOffset: 4
        }]
      }
    
    const myChart =
        new Chart("pieChart", {
        type: "pie",
        data: data,
        options: {}
      });
}
};

setupChar()