namespace Moj.Keshet.Shared.Enums.DatabaseEnums
{
	public enum RequestsStatusTypesEnum
	{
		InHandling = 6,
		WaitingForFix = 7,
		AppraisalApproved = 8,
		WaitingForManager = 9,
		Closed = 11,
		Canceled = 12,
		ControlUnitApproved = 13,
		RejectedByManager = 14,
		RejectedByControlUnit = 15,
		InException = 16,
		CanceledByOrganization = 17,
		PendingProcess = 18,
		DocumentsProcessFailed = 19,
	}
}
