const svgWidth = 500;
const barHeight = 30;
const barGap = 5;
const colors = ['#007bff', '#28a745', '#dc3545', '#ffc107', '#6f42c1'];

const svg = d3.select("#chart")
    .append("svg")
    .attr("width", svgWidth)
    .attr("height", 0);

document.getElementById("updateBtn").addEventListener("click", () => {
    const input = document.getElementById("dataInput").value.trim();

    const isValid = /^(\d+\s*,\s*)*\d+\s*$/.test(input);
    const validationMsg = document.getElementById("validationMessage");

    if (!isValid) {
        validationMsg.textContent = "Enter only numbers separated by commas (3, 4, 7)";
        validationMsg.style.display = "block";
        return;
    } else {
        validationMsg.textContent = "";
        validationMsg.style.display = "none";
    }

    const data = input.split(",").map(d => parseInt(d.trim()));

    const svgHeight = data.length * (barHeight + barGap);
    svg.attr("height", svgHeight);

    svg.selectAll("*").remove();

    const xScale = d3.scaleLinear()
        .domain([0, d3.max(data)])
        .range([0, svgWidth - 20]);

    svg.selectAll("rect")
        .data(data)
        .enter()
        .append("rect")
        .attr("x", 0)
        .attr("y", (d, i) => i * (barHeight + barGap))
        .attr("width", d => xScale(d))
        .attr("height", barHeight)
        .attr("fill", (d, i) => colors[i % colors.length]);

    svg.selectAll("text")
        .data(data)
        .enter()
        .append("text")
        .attr("x", d => xScale(d) - 5)
        .attr("y", (d, i) => i * (barHeight + barGap) + barHeight / 2 + 5)
        .text(d => d)
        .attr("text-anchor", "end")
        .attr("fill", "#fff")
        .attr("font-size", "12px");
});

document.addEventListener("keydown", function (e) {
    if (e.key === "Enter") {
        document.getElementById("updateBtn").click();
    }
});