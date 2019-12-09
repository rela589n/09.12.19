#include <iostream>
#include <vector>

using namespace std;
typedef long long Int;
const Int INF = 2147483647;

Int getMinDistanceVertex(vector<Int> dist, vector<bool> visited) {
	Int min = INF;
	Int indx = -1;

	for (Int i = 0; i < dist.size(); ++i) {
		if (!visited[i] && dist[i] < min) {
			min = dist[i];
			indx = i;
		}
	}

	return indx;
}

vector<Int> getDistances(vector< vector<Int> > graph, Int start) {
	Int n = graph.size();
	vector<bool> visited(n, false);
	vector<Int> distances(n, INF);
	distances[start] = 0;

	Int current = start;
	while (~current) { // current != -1
		visited[current] = true;

		for (Int i = 0; i < n; ++i) {

			// graph[current][i] + distances[current] < distances[i]
			if (!visited[i] && graph[current][i] < distances[i] - distances[current]) {
				distances[i] = graph[current][i] + distances[current];
			}
		}

		current = getMinDistanceVertex(distances, visited);
	}

	return distances;
}

vector<vector<Int>> inputGraph(Int n) {
	vector<vector<Int>> graph(n, vector<Int>(n));

	for (Int i = 0; i < n; ++i) {
		for (Int j = 0; j < n; ++j) {
			cin >> graph[i][j];

			if (graph[i][j] == -1) {
				graph[i][j] = INF;
			}
		}
	}

	return graph;
}

int main()
{
	Int n, a, b;
	cin >> n >> a >> b;
	--a;
	--b;

	if (n == 1) {
		cout << 0 << endl;
		return 0;
	}

	vector<vector<Int>> graph = inputGraph(n);
	Int result = getDistances(graph, a)[b];

	if (result == INF) {
		result = -1;
	}
	cout << result;

	system("pause");

	return 0;
}

/*
3 1 2
0 -1 2
3 0 -1
-1 4 0
*/