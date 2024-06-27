document.addEventListener('DOMContentLoaded', function () {
    const voteForm = document.getElementById('voteForm');
    const resultsTableBody = document.querySelector('#resultsTable tbody');
    const jobSelect = document.getElementById('jobSelect');
    const levelSelect = document.getElementById('levelSelect');
    const averageSalaryDisplay = document.getElementById('averageSalary');
    const salaryChartCtx = document.getElementById('salaryChart').getContext('2d');
    let chart;

    let votes = [];

    voteForm.addEventListener('submit', function (event) {
        event.preventDefault();

        const formData = new FormData(voteForm);
        const vote = {};
        formData.forEach((value, key) => vote[key] = value);
        votes.push(vote);

        updateResultsTable();
        updateChart();
        voteForm.reset();
    });

    function updateResultsTable() {
        resultsTableBody.innerHTML = '';
        votes.forEach(vote => {
            const row = document.createElement('tr');
            for (const key in vote) {
                const cell = document.createElement('td');
                cell.textContent = vote[key];
                row.appendChild(cell);
            }
            resultsTableBody.appendChild(row);
        });
    }

    function updateChart() {
        const selectedJob = jobSelect.value;
        const selectedLevel = levelSelect.value;

        const filteredVotes = votes.filter(vote => {
            return (selectedJob === '' || vote.position === selectedJob) &&
                (selectedLevel === '' || vote.level === selectedLevel);
        });

        const salaryCounts = filteredVotes.reduce((acc, vote) => {
            const salary = vote.salary;
            acc[salary] = acc[salary] ? acc[salary] + 1 : 1;
            return acc;
        }, {});

        const chartLabels = Object.keys(salaryCounts);
        const chartData = Object.values(salaryCounts);

        const totalSalary = filteredVotes.reduce((sum, vote) => sum + parseFloat(vote.salary), 0);
        const averageSalary = filteredVotes.length ? (totalSalary / filteredVotes.length).toFixed(2) : 0;

        // Update average salary display
        averageSalaryDisplay.textContent = averageSalary;

        if (chart) {
            chart.destroy();
        }

        chart = new Chart(salaryChartCtx, {
            type: 'bar',
            data: {
                labels: chartLabels,
                datasets: [{
                    label: 'Number of Votes',
                    data: chartData,
                    backgroundColor: 'rgba(0, 123, 255, 0.5)',
                    borderColor: 'rgba(0, 123, 255, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }

    jobSelect.addEventListener('change', updateChart);
    levelSelect.addEventListener('change', updateChart);

    updateChart();
});
