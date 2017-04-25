declare module server {
	interface DeviceFeedReportSummaryDay {
		day: number;
		heaterOn: number[];
		atTargetTemp: number[];
	}
}
