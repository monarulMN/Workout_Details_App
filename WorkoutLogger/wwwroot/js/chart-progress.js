const ctx = document.getElementById('progressChart').getContext('2d');

const chart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Day 1', 'Day 2', 'Day 3'], // Replace with your session dates dynamically
        datasets: [{
            label: 'Bench Press (kg)',
            data: [50, 55, 60], // Replace with your actual weights dynamically
            borderColor: 'blue',
            fill: false
        }]
    },
    options: {
        responsive: true,
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
