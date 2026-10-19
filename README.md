# PROG7312 POE - Part 2

## How to test the Part 2 Requirements:

### 1. Testing the Priority Queue vs Message Queue
1. Run the `SmartX System` API.
2. Open Swagger UI and go to `POST /api/telemetry/ingest`.
3. Send a normal packet (`"IsCritical": false`). Note how it goes into the standard Queue.
4. Send a critical packet (`"IsCritical": true`). Note how the API processes this immediately via the PriorityQueue, bypassing the standard FIFO queue.

### 2. Testing the Stack (Undo Feature)
1. Run the `SmartX.Clients` frontend.
2. Navigate to the "Real-Time Command Stream" page.
3. Click "Trigger Pump A". 
4. Click "Undo Last Command". The UI will display a success message proving the Stack `Pop()` function worked.

### 3. Testing the Dictionary and HashSet
- **Dictionary:** The API uses a `Dictionary<string, string>` to store devices via MAC Address for O(1) instant lookups.
- **HashSet:** Send a POST to `/api/telemetry/ingest` with `"Value": -1` (Disconnect Alert) for the same MAC address twice. The HashSet will prevent the system from logging the duplicate alert.

### 4. Testing the Predictive Engine
1. In the UI, type "Pump A" into the search bar a few times.
2. Use Swagger to send a POST request to `/api/telemetry/ingest` with `"Value": 15.0` and `"DeviceMacAddress": "Moisture-Sensor-B"`.
3. The UI will display a predictive "Automated Insight" suggesting you turn on Pump A.