SELECT G.NAMEGROUP, COUNT(*) AS NUMBER_OF_STUDENTS
FROM GROUPS G
INNER JOIN STUDENTS S ON G.GROUP_ID = S.GROUP_ID
GROUP BY G.GROUP_ID, G.NAMEGROUP
HAVING COUNT(*) < 10;
