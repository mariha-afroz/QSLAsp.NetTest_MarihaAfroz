-- Creates an index on 'EmployeeId' and 'ReviewScore' in 'PerformanceReviews' where 'ReviewScore' is not null.
-- Optimizes query performance for non-null review scores.

CREATE INDEX idx_PerformanceReview_Score ON PerformanceReviews(EmployeeId, ReviewScore)
WHERE ReviewScore IS NOT NULL;